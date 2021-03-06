﻿using Lexiconner.Domain.Dtos.CustomCollections;
using Lexiconner.Domain.Entitites.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexiconner.Domain.Entitites
{
    public class CustomCollectionEntity : BaseEntity
    {
        public CustomCollectionEntity()
        {
            Children = new List<CustomCollectionEntity>();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        public string Name { get; set; }
        public bool IsRoot { get; set; }
        public bool IsSelected { get; set; }
        public List<CustomCollectionEntity> Children { get; set; }


        #region Helper methods

        public void AddChildCollection(string parentCollectionId, CustomCollectionEntity entity)
        {
            if(parentCollectionId == null || this.Id == parentCollectionId)
            {
                this.Children.Add(entity);
            }
            else
            {
                this.Children.ForEach(x =>
                {
                    x.AddChildCollection(parentCollectionId, entity);
                });
            }
        }

        public void UpdateSelf(CustomCollectionUpdateDto updateDto)
        {
            this.Name = updateDto.Name;
        }

        public void UpdateChildCollection(string collectionId, CustomCollectionUpdateDto updateDto)
        {
            if(this.Id == collectionId)
            {
                this.UpdateSelf(updateDto);
            }
            else
            {
                this.Children.ForEach(x =>
                {
                    x.UpdateChildCollection(collectionId, updateDto);
                });
            }
        }

        public void MarkCollectionAsSelected(string collectionId)
        {
            // deselect all
            this.MarkCollectionAndChildsAsNotSelected();


            // mark as selected
            if (this.Id == collectionId)
            {
                this.IsSelected = true;
            }
            else
            {
                this.Children.ForEach(x =>
                {
                    x.MarkCollectionAsSelected(collectionId);
                });
            }
        }

        public void MarkCollectionAndChildsAsNotSelected()
        {
            this.IsSelected = false;
            this.Children.ForEach(x =>
            {
                x.MarkCollectionAndChildsAsNotSelected();
            });
        }

        public void RemoveChildCollection(string collectionId)
        {
            var existing = this.Children.FirstOrDefault(x => x.Id == collectionId);
            if(existing != null)
            {
                this.Children.Remove(existing);
            }
            else
            {
                this.Children.ForEach(x =>
                {
                    x.RemoveChildCollection(collectionId);
                });
            }
        }

        public void DuplicateCollection(string collectionId)
        {
            if (this.Id == collectionId && this.IsRoot)
            {
                // do nothing
            }
            else if (this.Children.Any(x => x.Id == collectionId))
            {
                int sourceIndex = this.Children.FindIndex(0, x => x.Id == collectionId);
                var source = this.Children.First(x => x.Id == collectionId);
                var duplicate = JsonConvert.DeserializeObject<CustomCollectionEntity>(JsonConvert.SerializeObject(source));
                
                // assign new ids
                duplicate.RegenerateId();
                duplicate.Children.ForEach(x =>
                {
                    x.RegenerateId();
                });
                duplicate.Name += " (Duplicate)";

                this.Children.Insert(sourceIndex + 1, duplicate);
            }
            else
            {
                this.Children.ForEach(x =>
                {
                    x.DuplicateCollection(collectionId);
                });
            }
        }

        public CustomCollectionEntity FindCollectionById(string collectionId)
        {
            if(this.Id == collectionId)
            {
                return this;
            }
            else
            {
                foreach (var item in this.Children)
                {
                    var result = item.FindCollectionById(collectionId);
                    if(result != null)
                    {
                        return result;
                    }
                }
                return null;
            }
        }

        public CustomCollectionEntity FindCollectionByName(string collectionName)
        {
            if (this.Name == collectionName)
            {
                return this;
            }
            else
            {
                foreach (var item in this.Children)
                {
                    var result = item.FindCollectionByName(collectionName);
                    if (result != null)
                    {
                        return result;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Returns id of given collection and all parent collections counting the current collection as root.
        /// </summary>
        /// <param name="collectionId"></param>
        /// <returns></returns>
        public List<string> GetCollectionChainIds(string collectionId)
        {
            if(this.Id == collectionId)
            {
                return new List<string>() { this.Id };
            }
            else
            {
                if (this.Children.Count == 0)
                {
                    return new List<string>();
                }

                var childrenResults = this.Children.SelectMany(x => x.GetCollectionChainIds(collectionId).Where(y => y != null).ToList()).ToList();
                if(childrenResults.Any())
                {
                    childrenResults.Add(this.Id);
                    return childrenResults;
                }
                else
                {
                    return new List<string>();
                }
            }
        }

        #endregion
    }
}

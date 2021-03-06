﻿using Lexiconner.Domain.Dtos.Words;
using Lexiconner.Domain.Enums;
using Lexiconner.Domain.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Lexiconner.Api.Dtos.WordsTrainings
{
    public class WordMeaningTrainingDto
    {
        public WordMeaningTrainingDto()
        {
            Items = new List<WordMeaningTrainingItemDto>();
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public TrainingType TrainingType => TrainingType.WordMeaning;
        public string TrainingTypeFormatted => EnumHelper<TrainingType>.GetDisplayValue(TrainingType.WordMeaning);
        public IEnumerable<WordMeaningTrainingItemDto> Items { get; set; }
    }

    public class WordMeaningTrainingItemDto
    {
        public WordMeaningTrainingItemDto()
        {
            PossibleOptions = new List<WordMeaningTrainingOptionDto>();
        }

        public WordDto Word { get; set; }
        public IEnumerable<WordMeaningTrainingOptionDto> PossibleOptions { get; set; }
    }

    public class WordMeaningTrainingOptionDto
    {
        public WordMeaningTrainingOptionDto()
        {
            RandomId = Guid.NewGuid().ToString();
        }

        public string RandomId { get; set; }
        public string Value { get; set; }
        public bool IsCorrect { get; set; }
    }
}

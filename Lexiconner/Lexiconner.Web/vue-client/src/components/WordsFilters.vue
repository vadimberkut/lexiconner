<template>
    <div class="mb-3">
        <form v-on:submit.prevent="() => {}" class="form-inline">
            <!-- Search -->
            <div class="form-group mr-3">
                <label class="sr-only" for="wordsRequestParams__search">Search</label>
                <input 
                    v-bind:value="sharedState.wordsRequestParams.search"
                    v-on:input="onSearchChange"
                    type="text" 
                    class="form-control" 
                    id="wordsRequestParams__search" 
                    placeholder="Search"
                >
            </div>

            <!-- <toggle-button 
                v-on:value="sharedState.wordsRequestParams.isFavourite || false"
                v-bind:sync="true"
                v-on:change="onIsFavoriteChange"
                v-bind:labels="{checked: '★', unchecked: '⁂'}"
                v-bind:font-size="16"
                v-bind:color="{checked: '#ffc107', unchecked: '#6c757d'}"
                v-bind:class="' mr-3'"
            /> -->

            <!-- Favorite -->
            <div class="form-group mr-3 cursor-pointer">
                <!-- <i v-on:click="setIsFavorite(null)" v-bind:class="{'text-warning': sharedState.wordsRequestParams.isFavourite === null}" class="fas fa-star-half-alt mr-1"></i> -->
                <!-- <i v-on:click="setIsFavorite(true)" v-bind:class="{'text-warning': sharedState.wordsRequestParams.isFavourite === true}" class="fas fa-star mr-1"></i> -->
                <!-- <i v-on:click="setIsFavorite(false)" v-bind:class="{'text-warning': sharedState.wordsRequestParams.isFavourite === false}" class="far fa-star"></i> -->
                
                <i 
                    v-if="sharedState.wordsRequestParams.isFavourite"
                    v-on:click="setIsFavorite(!sharedState.wordsRequestParams.isFavourite)" 
                    class="fas fa-star text-warning"
                ></i>
                <i 
                    v-if="!sharedState.wordsRequestParams.isFavourite"
                    v-on:click="setIsFavorite(!sharedState.wordsRequestParams.isFavourite)" 
                    class="far fa-star"
                ></i>
            </div>

             <!-- Trained/Not trained -->
            <div class="form-group mr-3 cursor-pointer">
                <div class="form-check form-check-inline">
                    <input  v-on:change="(e) => setIsTrained(e.target.checked ? true : null)" 
                        id="inlineCheckbox1"
                        class="form-check-input" 
                        type="checkbox" 
                        value="option1"
                        v-bind:checked="sharedState.wordsRequestParams.isTrained === true"
                    >
                    <label class="form-check-label" for="inlineCheckbox1">Trained</label>
                </div>
                <div class="form-check form-check-inline mr-0">
                    <input  v-on:change="(e) => setIsTrained(e.target.checked ? false : null)" 
                        id="inlineCheckbox2"
                        class="form-check-input" 
                        type="checkbox" 
                        value="option2"
                        v-bind:checked="sharedState.wordsRequestParams.isTrained === false"
                    >
                    <label class="form-check-label" for="inlineCheckbox2">Not trained</label>
                </div>
            </div>

            <!-- Shuffle -->
            <div class="form-group mr-3 cursor-pointer">
                <i 
                    v-on:click="setIsShuffle(!sharedState.wordsRequestParams.isShuffle)" 
                    v-bind:class="{'text-info': sharedState.wordsRequestParams.isShuffle === true}"
                    class="fas fa-random"
                ></i>
            </div>

            <!-- Reload -->
            <div class="form-group mr-3">
                <button v-on:click="reload" type="button" class="btn custom-btn-normal">
                    <i class="fas fa-sync-alt"></i>
                </button>
            </div>

            <!-- Reset -->
            <div class="form-group mr-3">
                <button v-on:click="resetRequestParams" type="button" class="btn custom-btn-normal">
                    <i class="fas fa-times"></i>
                </button>
            </div>
        </form>
    </div>
</template>

<script>
// @ is an alias to /src
import { mapState, mapGetters } from 'vuex';
import _ from 'lodash';
import { ToggleButton } from 'vue-js-toggle-button';
import { storeTypes } from '@/constants/index';
import authService from '@/services/authService';
import notificationUtil from '@/utils/notification';
import RowLoader from '@/components/loaders/RowLoader';
import LoadingButton from '@/components/LoadingButton';

export default {
    name: 'words-filters',
    props: {
        onChange: {
            type: Function,
            required: false,
            default: null,
        },
    },
    components: {
        // RowLoader,
        // LoadingButton,
        // ToggleButton,
    },
    data: function() {
        return {
            privateState: {
                storeTypes: storeTypes,
            },
        };
    },
    computed: {
        // local computed go here

        // store state computed go here
        ...mapState({
            sharedState: state => state,
        }),
    },
    created: async function() {
        
    },
    mounted: function() {
    },
    updated: function() {
    },
    beforeDestroy: function() {
    },
    destroyed: function() {
        this.resetRequestParams();
    },

    methods: {
        callOnChange: function() {
            if(this.onChange) {
                this.onChange();
            }
        },
        callOnChangeDebounce: _.debounce(function() {
             if(this.onChange) {
                this.onChange();
            }
        }, 500),
        onSearchChange: function(e) {
            this.$store.commit(storeTypes.STUDY_ITEMS_REQUEST_PARAMS_SET, {
                search: e.target.value,
            });
            this.callOnChangeDebounce();
        },
        onIsFavoriteChange: function({value, tag, srcEvent}) {
            this.$store.commit(storeTypes.STUDY_ITEMS_REQUEST_PARAMS_SET, {
                isFavourite: value,
            });
             this.callOnChange();
        },
        setIsFavorite: function(value) {
            this.$store.commit(storeTypes.STUDY_ITEMS_REQUEST_PARAMS_SET, {
                isFavourite: value,
            });
            this.callOnChange();
        },
        setIsShuffle: function(value) {
            this.$store.commit(storeTypes.STUDY_ITEMS_REQUEST_PARAMS_SET, {
                isShuffle: value,
            });
            this.callOnChange();
        },
        setIsTrained: function(value) {
            this.$store.commit(storeTypes.STUDY_ITEMS_REQUEST_PARAMS_SET, {
                isTrained: value,
            });
            this.callOnChange();
        },
        reload: function() {
            this.callOnChange();
        },
        resetRequestParams: function() {
            this.$store.commit(storeTypes.STUDY_ITEMS_REQUEST_PARAMS_RESET, {});
            this.callOnChange();
        },
    },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>

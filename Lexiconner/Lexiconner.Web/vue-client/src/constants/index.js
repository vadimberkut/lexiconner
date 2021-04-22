'use strict';

const storeTypes = {
    'LOADING_SET': 'LOADING_SET',

    'ENUMS_LOAD': 'ENUMS_LOAD',
    'ENUMS_SET': 'ENUMS_SET',

    'CONFIG_LOAD': 'CONFIG_LOAD',
    'CONFIG_SET': 'CONFIG_SET',

    'TERMS_OF_USE_LOAD': 'TERMS_OF_USE_LOAD',
    'TERMS_OF_USE_SET': 'TERMS_OF_USE_SET',
    'COUNTRIES_LOAD': 'COUNTRIES_LOAD',
    'COUNTRIES_SET': 'COUNTRIES_SET',
    'LANGUAGES_LOAD': 'LANGUAGES_LOAD',
    'LANGUAGES_SET': 'LANGUAGES_SET',
    'TIMEZONES_LOAD': 'TIMEZONES_LOAD',
    'TIMEZONES_SET': 'TIMEZONES_SET',

    'AUTH_USER_SET': 'AUTH_USER_SET',
    'AUTH_USER_RESET': 'AUTH_USER_RESET',

    'USER_INFO_LOAD': 'USER_INFO_LOAD',
    'USER_INFO_SET': 'USER_INFO_SET',
    'USER_INFO_UPDATE': 'USER_INFO_UPDATE',
    'USER_INFO_NOTIFICATIONS_UPDATE': 'USER_INFO_NOTIFICATIONS_UPDATE',
    'USER_INFO_TIMEZONE_SET': 'USER_INFO_TIMEZONE_SET',
    'USER_INFO_CURRENT_COMPANY_SET': 'USER_INFO_CURRENT_COMPANY_SET',

    'PROFILE_LOAD': 'PROFILE_LOAD',
    'PROFILE_SET': 'PROFILE_SET',
    'PROFILE_SELECT_LEARNING_LANGUAGE': 'PROFILE_SELECT_LEARNING_LANGUAGE',

    'WORDS_LOAD': 'WORDS_LOAD',
    'WORDS_REQUEST_PARAMS_SET': 'WORDS_REQUEST_PARAMS_SET',
    'WORDS_ITEMS_REQUEST_PARAMS_RESET': 'WORDS_ITEMS_REQUEST_PARAMS_RESET',
    'WORDS_LOAD_SET': 'WORDS_LOAD_SET',
    'WORD_LOAD': 'WORD_LOAD',
    'WORD_LOAD_SET': 'WORD_LOAD_SET',
    'WORD_CREATE': 'WORD_CREATE',
    'WORD_CREATE_SET': 'WORD_CREATE_SET',
    'WORD_UPDATE': 'WORD_UPDATE',
    'WORD_UPDATE_SET': 'WORD_UPDATE_SET',
    'WORD_DELETE': 'WORD_DELETE',
    'WORD_DELETE_SET': 'WORD_DELETE_SET',
    'WORD_IMAGES_FIND': 'WORD_IMAGES_FIND',
    'WORD_IMAGES_FIND_SET': 'WORD_IMAGES_FIND_SET',
    'WORD_IMAGES_UPDATE': 'WORD_IMAGES_UPDATE',

    'WORD_ADD_TO_FAVOURITES': 'WORD_ADD_TO_FAVOURITES',
    'WORD_DELETE_FROM_FAVOURITES': 'WORD_DELETE_FROM_FAVOURITES',
    'WORD_IS_FAVOURITE_SET': 'WORD_IS_FAVOURITE_SET',

    'WORD_EXAMPLES_LOAD': 'WORD_EXAMPLES_LOAD',
    'WORD_EXAMPLES_SET': 'WORD_EXAMPLES_SET',
    'WORD_PRONUNCIATION_AUDIO_LOAD': 'WORD_PRONUNCIATION_AUDIO_LOAD',
    'WORD_PRONUNCIATION_AUDIO_SET': 'WORD_PRONUNCIATION_AUDIO_SET',
    
    'WORD_TRAINING_STATS_LOAD': 'WORD_TRAINING_STATS_LOAD',
    'WORD_TRAINING_STATS_SET': 'WORD_TRAINING_STATS_SET',
    'WORD_TRAINING_MARK_AS_TRAINED': 'WORD_TRAINING_MARK_AS_TRAINED',
    'WORD_TRAINING_MARK_AS_TRAINED_SET': 'WORD_TRAINING_MARK_AS_TRAINED_SET',
    'WORD_TRAINING_MARK_AS_NOT_TRAINED': 'WORD_TRAINING_MARK_AS_NOT_TRAINED',
    'WORD_TRAINING_MARK_AS_NOT_TRAINED_SET': 'WORD_TRAINING_MARK_AS_NOT_TRAINED_SET',
    'WORD_TRAINING_FLASHCARDS_START': 'WORD_TRAINING_FLASHCARDS_START',
    'WORD_TRAINING_FLASHCARDS_START_SET': 'WORD_TRAINING_FLASHCARDS_START_SET',
    'WORD_TRAINING_FLASHCARDS_SAVE': 'WORD_TRAINING_FLASHCARDS_SAVE',
    'WORD_TRAINING_WORDMEANING_START': 'WORD_TRAINING_WORDMEANING_START',
    'WORD_TRAINING_WORDMEANING_START_SET': 'WORD_TRAINING_WORDMEANING_START_SET',
    'WORD_TRAINING_WORDMEANING_SAVE': 'WORD_TRAINING_WORDMEANING_SAVE',
    'WORD_TRAINING_MEANINGWORD_START': 'WORD_TRAINING_MEANINGWORD_START',
    'WORD_TRAINING_MEANINGWORD_START_SET': 'WORD_TRAINING_MEANINGWORD_START_SET',
    'WORD_TRAINING_MEANINGWORD_SAVE': 'WORD_TRAINING_MEANINGWORD_SAVE',
    'WORD_TRAINING_MATCHWORDS_START': 'WORD_TRAINING_MATCHWORDS_START',
    'WORD_TRAINING_MATCHWORDS_START_SET': 'WORD_TRAINING_MATCHWORDS_START_SET',
    'WORD_TRAINING_MATCHWORDS_SAVE': 'WORD_TRAINING_MATCHWORDS_SAVE',
    'WORD_TRAINING_BUILDWORDS_START': 'WORD_TRAINING_BUILDWORDS_START',
    'WORD_TRAINING_BUILDWORDS_START_SET': 'WORD_TRAINING_BUILDWORDS_START_SET',
    'WORD_TRAINING_BUILDWORDS_SAVE': 'WORD_TRAINING_BUILDWORDS_SAVE',
    'WORD_TRAINING_LISTENWORDS_START': 'WORD_TRAINING_LISTENWORDS_START',
    'WORD_TRAINING_LISTENWORDS_START_SET': 'WORD_TRAINING_LISTENWORDS_START_SET',
    'WORD_TRAINING_LISTENWORDS_SAVE': 'WORD_TRAINING_LISTENWORDS_SAVE',

    'CUSTOM_COLLECTIONS_LOAD': 'CUSTOM_COLLECTIONS_LOAD',
    'CUSTOM_COLLECTIONS_SET': 'CUSTOM_COLLECTIONS_SET',
    'CUSTOM_COLLECTION_CURRENT_SET': 'CUSTOM_COLLECTION_CURRENT_SET',
    'CUSTOM_COLLECTION_CREATE': 'CUSTOM_COLLECTION_CREATE',
    'CUSTOM_COLLECTION_UPDATE': 'CUSTOM_COLLECTION_UPDATE',
    'CUSTOM_COLLECTION_MARK_AS_SELECTED': 'CUSTOM_COLLECTION_MARK_AS_SELECTED',
    'CUSTOM_COLLECTION_DELETE': 'CUSTOM_COLLECTION_DELETE',
    'CUSTOM_COLLECTION_DUPLICATE': 'CUSTOM_COLLECTION_DUPLICATE',

    'USER_DICTIONARY_LOAD': 'USER_DICTIONARY_LOAD',
    'USER_DICTIONARY_LOAD_SET': 'USER_DICTIONARY_LOAD_SET',
    'USER_DICTIONARY_WORD_SET_ADD': 'USER_DICTIONARY_WORD_SET_ADD',
    'USER_DICTIONARY_WORD_SET_CREATE': 'USER_DICTIONARY_WORD_SET_CREATE',
    'USER_DICTIONARY_WORD_SET_UPDATE': 'USER_DICTIONARY_WORD_SET_UPDATE',
    'USER_DICTIONARY_WORD_SET_DELETE': 'USER_DICTIONARY_WORD_SET_DELETE',
    'USER_DICTIONARY_WORD_SET_CURRENT_SET': 'USER_DICTIONARY_WORD_SET_CURRENT_SET',

    'WORD_SETS_REQUEST_PARAMS_SET': 'WORD_SETS_REQUEST_PARAMS_SET',
    'WORD_SETS_ITEMS_REQUEST_PARAMS_RESET': 'WORD_SETS_ITEMS_REQUEST_PARAMS_RESET',
    'WORD_SETS_LOAD': 'WORD_SETS_LOAD',
    'WORD_SETS_LOAD_SET': 'WORD_SETS_LOAD_SET',
    

    'USER_FILMS_LOAD': 'USER_FILMS_LOAD',
    'USER_FILMS_REQUEST_PARAMS_SET': 'USER_FILMS_REQUEST_PARAMS_SET',
    'USER_FILMS_REQUEST_PARAMS_RESET': 'USER_FILMS_REQUEST_PARAMS_RESET',
    'USER_FILMS_SET': 'USER_FILMS_SET',
    'USER_FILM_LOAD': 'USER_FILM_LOAD',
    'USER_FILM_CREATE': 'USER_FILM_CREATE',
    'USER_FILM_CREATE_SET': 'USER_FILM_CREATE_SET',
    'USER_FILM_UPDATE': 'USER_FILM_UPDATE',
    'USER_FILM_UPDATE_SET': 'USER_FILM_UPDATE_SET',
    'USER_FILM_DELETE': 'USER_FILM_DELETE',
    'USER_FILM_DELETE_SET': 'USER_FILM_DELETE_SET',

    'NAV_VISIBILITY_SET': 'NAV_VISIBILITY_SET',

    'ERROR_PAGE_DATA_SET': 'ERROR_PAGE_DATA_SET',
    'ERROR_PAGE_DATA_RESET': 'ERROR_PAGE_DATA_RESET',
}

export {
    storeTypes,
}

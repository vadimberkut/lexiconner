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

    'STUDY_ITEMS_LOAD': 'STUDY_ITEMS_LOAD',
    'STUDY_ITEMS_REQUEST_PARAMS_SET': 'STUDY_ITEMS_REQUEST_PARAMS_SET',
    'STUDY_ITEMS_REQUEST_PARAMS_RESET': 'STUDY_ITEMS_REQUEST_PARAMS_RESET',
    'STUDY_ITEMS_LOAD_SET': 'STUDY_ITEMS_LOAD_SET',
    'STUDY_ITEM_LOAD': 'STUDY_ITEM_LOAD',
    'STUDY_ITEM_LOAD_SET': 'STUDY_ITEM_LOAD_SET',
    'STUDY_ITEM_CREATE': 'STUDY_ITEM_CREATE',
    'STUDY_ITEM_CREATE_SET': 'STUDY_ITEM_CREATE_SET',
    'STUDY_ITEM_UPDATE': 'STUDY_ITEM_UPDATE',
    'STUDY_ITEM_UPDATE_SET': 'STUDY_ITEM_UPDATE_SET',
    'STUDY_ITEM_DELETE': 'STUDY_ITEM_DELETE',
    'STUDY_ITEM_DELETE_SET': 'STUDY_ITEM_DELETE_SET',

    'STUDY_ITEM_ADD_TO_FAVOURITES': 'STUDY_ITEM_ADD_TO_FAVOURITES',
    'STUDY_ITEM_DELETE_FROM_FAVOURITES': 'STUDY_ITEM_DELETE_FROM_FAVOURITES',
    'STUDY_ITEM_IS_FAVOURITE_SET': 'STUDY_ITEM_IS_FAVOURITE_SET',
    
    'STUDY_ITEM_TRAINING_STATS_LOAD': 'STUDY_ITEM_TRAINING_STATS_LOAD',
    'STUDY_ITEM_TRAINING_STATS_SET': 'STUDY_ITEM_TRAINING_STATS_SET',
    'STUDY_ITEM_TRAINING_MARK_AS_TRAINED': 'STUDY_ITEM_TRAINING_MARK_AS_TRAINED',
    'STUDY_ITEM_TRAINING_MARK_AS_TRAINED_SET': 'STUDY_ITEM_TRAINING_MARK_AS_TRAINED_SET',
    'STUDY_ITEM_TRAINING_MARK_AS_NOT_LEARNED': 'STUDY_ITEM_TRAINING_MARK_AS_NOT_LEARNED',
    'STUDY_ITEM_TRAINING_MARK_AS_NOT_LEARNED_SET': 'STUDY_ITEM_TRAINING_MARK_AS_NOT_LEARNED_SET',
    'STUDY_ITEM_TRAINING_FLASHCARDS_START': 'STUDY_ITEM_TRAINING_FLASHCARDS_START',
    'STUDY_ITEM_TRAINING_FLASHCARDS_START_SET': 'STUDY_ITEM_TRAINING_FLASHCARDS_START_SET',
    'STUDY_ITEM_TRAINING_FLASHCARDS_SAVE': 'STUDY_ITEM_TRAINING_FLASHCARDS_SAVE',
    'STUDY_ITEM_TRAINING_WORDMEANING_START': 'STUDY_ITEM_TRAINING_WORDMEANING_START',
    'STUDY_ITEM_TRAINING_WORDMEANING_START_SET': 'STUDY_ITEM_TRAINING_WORDMEANING_START_SET',
    'STUDY_ITEM_TRAINING_WORDMEANING_SAVE': 'STUDY_ITEM_TRAINING_WORDMEANING_SAVE',

    'CUSTOM_COLLECTIONS_LOAD': 'CUSTOM_COLLECTIONS_LOAD',
    'CUSTOM_COLLECTIONS_SET': 'CUSTOM_COLLECTIONS_SET',
    'CUSTOM_COLLECTION_CURRENT_SET': 'CUSTOM_COLLECTION_CURRENT_SET',
    'CUSTOM_COLLECTION_CREATE': 'CUSTOM_COLLECTION_CREATE',
    'CUSTOM_COLLECTION_UPDATE': 'CUSTOM_COLLECTION_UPDATE',
    'CUSTOM_COLLECTION_DELETE': 'CUSTOM_COLLECTION_DELETE',
    'CUSTOM_COLLECTION_DUPLICATE': 'CUSTOM_COLLECTION_DUPLICATE',

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

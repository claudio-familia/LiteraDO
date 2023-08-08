export interface Story {
    generalInformation: GeneralInformation;
    detail: Detail
}

export interface GeneralInformation {
    title: string;
    category: string;
    description: string;
}

export interface Detail {
    tags: string[];
    audience: string;
    language: string;
    matureContent: boolean;
}

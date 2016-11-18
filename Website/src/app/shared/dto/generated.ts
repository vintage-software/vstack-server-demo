import {
    SecureDto
} from './references';

export interface Account extends SecureDto {
    id: number;
    emailAddress: string;
    password: string;
    firstName: string;
    lastName: string;
}

export interface Note extends SecureDto {
    id: number;
    notebookId: number;
    title: string;
    content: string;
    notebook: Notebook;
}

export interface Notebook extends SecureDto {
    id: number;
    accountId: number;
    title: string;
    description: string;
    notes: Note[];
}
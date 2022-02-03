import { FavouriteBookList } from "./favouritebooklist";


export interface User {
    email : string;
    token: string;
    id: string;
    userName:string;
    favouristBookList? : FavouriteBookList;
    bookReviews: Reviews[];
    
}

export interface Reviews{
    id: number;
    publishedDate: string;
    title: string;
    description: string;
    bookId: number;
    rating: number;
    pictureUrl: string;
}
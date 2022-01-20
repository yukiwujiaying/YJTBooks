import { FavouriteBookList } from "./favouritebooklist";


export interface User {
    email : string;
    token: string;
    favouristBookList? : FavouriteBookList;
}
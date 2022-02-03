export interface Book {
    id: number;
    title: string;
    author: string;
    link: string;
    synopsis: string;
    price: number;
    pictureUrl: string;
    genre: string;
    isFavourite: boolean;
    bookReviews: Reviews[];
}

export interface BookParams {
    orderBy: string;
    searchTerm?: string;
    genres: string[];
    pageNumber:number;
    pageSize: number;
}

export interface Reviews{
    id: number;
    publishedDate: string;
    title: string;
    userId: string;
    description: string;
    bookId: number;
    rating: number;
    //user: UserForReview;    
    userName:string;
}

// export interface UserForReview{
//     userName:string;
// }
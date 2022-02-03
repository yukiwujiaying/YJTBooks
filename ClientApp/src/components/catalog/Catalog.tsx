import { Grid, Paper } from '@mui/material';
import React from 'react';
import { useEffect } from "react";
import AppPagination from '../../app/components/AppPagination';
import CheckboxButtons from '../../app/components/CheckboxButtons';
import RadioButtonGroup from '../../app/components/RadioButtonGroup';
import LoadingComponent from '../../app/layout/LoadingComponent';
import { useAppDispatch, useAppSelector } from '../../app/store/configureStore';
import BookList from "./BookList";
import BookSearch from './BookSearch';
import { bookSelectors, fetchBooksAsync, fetchFilters, setBookParams, setPageNumber } from './catalogSlice';

const sortOptions = [
    { value: 'name', label: 'Alphabetical' },
    { value: 'priceDesc', label: 'Price - High to low' },
    { value: 'Price', label: 'Price - Low to high' },
]
export default function Catalog() {
    const books = useAppSelector(bookSelectors.selectAll)
    const {filtersLoaded,booksLoaded, genres, bookParams,metaData } = useAppSelector(state => state.catalog);
    const dispatch = useAppDispatch();

    // const [books, setbooks] = useState<Book[]>([]);
    // const [loading, setLoading] =  useState(true);

    // useEffect(()=>{
    //   agent.Catalog.list().then(books => setbooks(books))
    //                       .catch(error => console.log(error))
    //                       .finally(()=>setLoading(false))
    // }, []);
    

    useEffect(() => {
        if (!booksLoaded) dispatch(fetchBooksAsync());
    }, [booksLoaded, dispatch])

    useEffect(() => {
        if (!filtersLoaded) dispatch(fetchFilters());
    }, [dispatch, filtersLoaded])

    if (!filtersLoaded) return <LoadingComponent message="Loading products..." />

    console.log(genres);
      
    return (
        <Grid container spacing={4}>            
            <Grid item xs={3}>
                <Paper sx={{ mb: 2 }}>
                    <BookSearch />      
                </Paper>
                <Paper sx={{ mb: 2, p: 2 }}>
                    <RadioButtonGroup
                        selectedValue={bookParams.orderBy}
                        options={sortOptions}
                        onChange={(event) => dispatch(setBookParams({ orderBy: event.target.value }))}
                    />
                </Paper>
                <Paper sx={{ mb: 2, p: 2 }}>
                    <CheckboxButtons
                        items={genres}
                        checked={bookParams.genres}
                        onChange={(items: string[]) => dispatch(setBookParams({ genres: items }))}
                    />
                </Paper>
            </Grid>
            <Grid item xs={9}>
                <BookList books={books}/>
            </Grid>
            <Grid item xs={3} />
            <Grid item xs={9} sx={{ mb: 2 }}>
                {/* we only loaded AppPagination when we have metaData */}
                {metaData &&
                    <AppPagination
                        metaData={metaData}
                        onPageChange={(page: number) => dispatch(setPageNumber({ pageNumber: page }))} />}
            </Grid>
            
        </Grid>
    );
}

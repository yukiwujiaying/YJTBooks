import { Paper, IconButton, InputBase, Divider, debounce } from '@mui/material';
import SearchIcon from '@material-ui/icons/Search';
import React, { useState } from 'react';
import { useAppSelector, useAppDispatch } from '../../app/store/configureStore';
import { setBookParams } from '../catalog/catalogSlice';
import { Link } from 'react-router-dom';


export default function Home() {
    const { bookParams } = useAppSelector(state => state.catalog);
    const [searchTerm, setSearchTerm] = useState(bookParams.searchTerm);
    const dispatch = useAppDispatch();
   

    const debouncedSearch = debounce((event: any) => {
        dispatch(setBookParams({ searchTerm: event.target.value }))
    }, 1500)

    return (
        <Paper
            component="form"
            className="searchBox"
            sx={{ p: '2px 4px', display: 'flex', alignItems: 'center', width: 400 }}
        >
            <InputBase
                sx={{ ml: 1, flex: 1 }}
                placeholder="Search Books"
                value={searchTerm || ''}
                onChange={(event: any) => {
                    setSearchTerm(event.target.value);
                    debouncedSearch(event);
                }}
            />
            <IconButton 
                type="submit" sx={{ p: '10px' }} 
                aria-label="search" 
                disabled={!searchTerm}
                component={Link} to={`/catalog`}
                >
                <SearchIcon />
            </IconButton>
            <Divider sx={{ height: 28, m: 0.5 }} orientation="vertical" />
        </Paper>
    )
}

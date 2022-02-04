import { Grade } from "@mui/icons-material";
import { AppBar, Badge, IconButton, List, ListItem, Switch, Toolbar, Typography,Box } from "@mui/material";
import React from "react";
import { Link, NavLink } from "react-router-dom";
import { ClearState } from "../../components/catalog/bookSlice";
import { useAppDispatch, useAppSelector } from "../store/configureStore";
import SignedInMenu from "./SignedInMenu";

interface Props{
    darkMode : boolean;
    handleThemeChange:() => void;
}

const midlinks=[
    {title:'catalog', path:'/catalog'},
    {title:'about', path:'/about'},
    {title:'contact', path:'/contact'}

]

const rightLinks =[
    {title:'login', path:'/login'},
    {title:'register', path:'/register'},
]

const navStyles={
    color: 'inherit', 
    typography:'h6',
    '&:hover': {
        color: 'grey.500'
    },
    '&.active':{
        color: 'text.secondary'
    },
    textDecoration:'none'
}
export default function Header({darkMode, handleThemeChange}:Props){
    const {favouriteBookList} = useAppSelector(state=>state.favouriteBookList);
    const {user} = useAppSelector(state=>state.account);
    const dispatch = useAppDispatch();
    console.log(favouriteBookList);
    const itemCount = favouriteBookList?.items.length;
    console.log("itemCount:", itemCount);
    return(
        <AppBar position='static' sx={{mb:4}}>
            <Toolbar sx={{display:'flex', justifyContent:'space-between', alignItems:'center'}}>
                <Box display='flex' alignItems='center'>
                    <Typography variant='h6' component={NavLink} to='/'  sx={navStyles}>
                        YJTBooks
                    </Typography>
                    <Switch checked={darkMode} onChange={handleThemeChange}/>
                </Box>
                

                <List sx={{display:'flex'}}>
                {midlinks.map(({title,path})=>(
                    <ListItem 
                    component={NavLink}
                    to={path}
                    key={path}
                    sx={navStyles}
                    onClick={()=>{dispatch(ClearState())}}
                    >
                        {title.toUpperCase()}
                    </ListItem>
                ))}
                </List>
                
                <Box display='flex' alignItems='center'>            
                    <IconButton component={Link} to='/favouriteBookList' size='large' sx={{color:'inherit'}}>
                        <Badge badgeContent={itemCount} color='secondary'>
                           <Grade onClick={()=>{dispatch(ClearState())}}/> 
                        </Badge>
                    </IconButton>

                    {user ? 
                        (<SignedInMenu/>) :
                        (<List sx={{display:'flex'}}>
                        {rightLinks.map(({title,path})=>(
                            <ListItem 
                            component={NavLink}
                            to={path}
                            key={path}
                            sx={navStyles}
                            onClick={()=>{dispatch(ClearState())}}
                            >
                                {title.toUpperCase()}
                            </ListItem>
                        ))}
                        </List>)
                    }
                </Box>
                
            </Toolbar>
           
            
        </AppBar>
    )
}
import { Grade } from "@mui/icons-material";
import { AppBar, Badge, IconButton, List, ListItem, Switch, Toolbar, Typography,Box } from "@mui/material";
import React from "react";
import { Link, NavLink } from "react-router-dom";
import { useStoreContext } from "../context/StoreContext";

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
    {title:'Profile', path:'/userprofile'}
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
    const {favouriteBookList} = useStoreContext();
    const itemCount = favouriteBookList?.items.reduce((sum,item) => sum + item.quantity,0)
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
                    >
                        {title.toUpperCase()}
                    </ListItem>
                ))}
                </List>
                
                <Box display='flex' alignItems='center'>            
                    <IconButton component={Link} to='/favouriteBookList' size='large' sx={{color:'inherit'}}>
                        <Badge badgeContent={itemCount} color='secondary'>
                           <Grade /> 
                        </Badge>
                    </IconButton>

                    <List sx={{display:'flex'}}>
                    {rightLinks.map(({title,path})=>(
                        <ListItem 
                        component={NavLink}
                        to={path}
                        key={path}
                        sx={navStyles}
                        >
                            {title.toUpperCase()}
                        </ListItem>
                    ))}
                    </List>
                </Box>
                
            </Toolbar>
           
            
        </AppBar>
    )
}
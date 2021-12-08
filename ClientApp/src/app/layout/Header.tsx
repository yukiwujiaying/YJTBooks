import { Grade } from "@mui/icons-material";
import { AppBar, Badge, IconButton, List, ListItem, Switch, Toolbar, Typography } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import { NavLink } from "react-router-dom";

interface Props{
    darkMode : boolean;
    handleThemeChange:() => void;
}

const midlinks=[
    {title:'catalog', path:'/catalog'},
    {title:'about', path:'/about'},

]

const rightLinks =[
    {title:'login', path:'/login'},
    {title:'register', path:'/register'}
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
                    <IconButton size='large' sx={{color:'inherit'}}>
                        <Badge badgeContent={4} color='secondary'>
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
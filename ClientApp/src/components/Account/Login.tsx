import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import TextField from '@mui/material/TextField';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { Link } from 'react-router-dom';
import { FieldValues, useForm } from 'react-hook-form';
import { Paper } from '@material-ui/core';
import { LoadingButton } from '@mui/lab';
import agent from '../../app/api/agent';

export default function Login() {

    const { register, handleSubmit, formState: { isSubmitting, errors, isValid } } = useForm({
    mode: 'all'
    })

    async function submitForm(data: FieldValues) {
        try {
            await agent.Account.login(data);
        } catch (error) {
            console.log(error);
        }
    }

    return (
            <Container component={Paper} maxWidth="sm"
                sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', p: 4 }}>
                    <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                        <LockOutlinedIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        Login
                    </Typography>
                    <Box component="form" onSubmit={handleSubmit(submitForm)} noValidate sx={{ mt: 1 }}>
                        <TextField
                    margin="normal"
                    fullWidth
                    label="Username"
                    autoFocus
                    {...register('username', { required: 'Username is required' })}
                    error={!!errors.username}
                    helperText={errors?.username?.message}
                        />
                        <TextField
                    margin="normal"
                    fullWidth
                    label="Password"
                    type="password"
                    {...register('password', { required: 'Password is required' })}
                    error={!!errors.password}
                    helperText={errors?.password?.message}
                        />
                <LoadingButton loading={isSubmitting}
                            disabled={!isValid}
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{ mt: 3, mb: 2 }}
                    >
                            Sign In
                        </LoadingButton>
                        <Grid container>
                            <Grid item xs>
                                <Link to='/register'>
                                    Forgot password?
                                </Link>
                            </Grid>
                            <Grid item>
                                <Link to='/register'>
                                    {"Don't have an account? Register"}
                                </Link>
                            </Grid>
                        </Grid>
                    </Box>
            </Container>
    );
}

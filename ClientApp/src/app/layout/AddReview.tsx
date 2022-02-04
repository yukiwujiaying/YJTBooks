import * as React from 'react';
import Rating from '@mui/material/Rating';
import Typography from '@mui/material/Typography';
import { Box, Grid, TextareaAutosize, TextField } from '@mui/material';
import { LoadingButton } from '@mui/lab';
import { useForm, Controller } from 'react-hook-form';
import { toast } from 'react-toastify';
import { useAppDispatch } from '../store/configureStore';
import { AddReview } from '../../components/catalog/bookSlice';





interface Props{
    bookId: number,
    userId: string
}
export default function BasicRating({bookId, userId}:Props) {
    const dispatch = useAppDispatch();

    const{register, handleSubmit,control, formState: {isSubmitting,errors, isValid}} = useForm({
        mode: 'all'
      })
    
    
    
    return (
        <Grid item xs={1} md={12}>
            <Typography component="legend">Write a review</Typography>
            <Box component="form" 
            
            onSubmit={handleSubmit((data)=>dispatch(AddReview({data,bookId, userId}))
                                                        .then(()=>{
                                                            toast.success('Review Added');
                                                            //myHistory.push(state?.path);
                                                            console.log(data);
                                                        }))} 
            noValidate sx={{ mt: 1 }}
          >
            
            <Controller
                        name="rating"
                        control={control}
                        rules={{ required: true }}
                        defaultValue=''
                        render={({ field: { onChange, value } }) =>
                            <Rating name="rating"
                                onChange={onChange}                                
                            />}
                        
                    />
            
            <Typography component="legend"></Typography>
            <TextField
                id="outlined-textarea"
                label="Review Title"
                placeholder="Title"
                multiline
                fullWidth
                variant="filled"
                {...register('title', {required: 'Title is required'})}
                error={!!errors.title}
                // show error message to user
                helperText={errors?.title?.message}
            />
            
            <TextareaAutosize
                aria-label="minimum height"
                minRows={6}
                placeholder="Say something..."
                style={{ width: 1150 }} 
                {...register('description', {required: 'Description is required'})}
            />
            <LoadingButton
                disabled={!isValid}
                loading={isSubmitting}
                type="submit"
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
            >
                Submit
            </LoadingButton>
            </Box>
        </Grid>
    );
}



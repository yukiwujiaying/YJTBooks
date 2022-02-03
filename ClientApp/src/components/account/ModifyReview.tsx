import * as React from 'react';
import Rating from '@mui/material/Rating';
import Typography from '@mui/material/Typography';
import { Card, CardContent, CardMedia, Grid, TextareaAutosize, TextField } from '@mui/material';
import { LoadingButton } from '@mui/lab';
import { useForm, Controller } from 'react-hook-form';
import { toast } from 'react-toastify';
import { ModifyReview } from './accountSlice';
import { useAppDispatch } from '../../app/store/configureStore';
import { myHistory } from '../../history';
import { useLocation } from 'react-router';


interface Props {
    id: number,
    closeReview: Function,
    pictureUrl: string,
    title: string,
    description: string,
    rating: number,

}


export default function ModifyReviewInProfile({ id, closeReview, pictureUrl, description, title, rating }: Props) {
    const dispatch = useAppDispatch();
    const { state } = useLocation();


    const { register, handleSubmit, control, formState: { isSubmitting, errors, isValid } } = useForm({
        mode: 'all'
    })



    return (
        <Grid item xs={1} md={12}>
            <Card sx={{ display: 'flex' }}>
                <CardMedia
                    component="img"
                    image={pictureUrl}
                    sx={{ objectFit: 'cover', bgcolor: 'primary.light', width: 190 }}
                />
                <CardContent component="form"

                    onSubmit={handleSubmit((data) => dispatch(ModifyReview({ data, id }))
                        .then(() => {
                            toast.success('Review Updated');
                            myHistory.push(state?.path);
                            console.log(data);
                            closeReview();
                        }))}
                    noValidate sx={{ flex: 1 }}
                >

                    <Typography component="legend"><span>Update a review</span></Typography>
                    <Controller
                        name="rating"
                        control={control}
                        rules={{ required: true }}
                        defaultValue=''
                        render={({ field: { onChange, value } }) =>
                            <Rating name="rating"
                                defaultValue={rating}
                                onChange={onChange}                                
                            />}
                        
                    />

                    <Typography component="legend"></Typography>
                    <TextField
                        id="outlined-textarea"
                        label="Title"
                        placeholder={title}
                        multiline
                        style={{ width: 900 }}
                        variant="filled"
                        {...register('title', { required: 'Title is required' })}
                        error={!!errors.title}
                        // show error message to user
                        helperText={errors?.title?.message}
                    />

                    <TextareaAutosize
                        aria-label="minimum height"
                        minRows={6}
                        placeholder={description}
                        style={{ width: 900 }}
                        {...register('description', { required: 'Description is required' })}
                    />
                    <LoadingButton
                        disabled={!isValid}
                        loading={isSubmitting}
                        type="submit"
                        style={{ width: 900 }}
                        variant="contained"
                        sx={{ mt: 3, mb: 2 }}
                    >
                        Submit
                    </LoadingButton>
                    <LoadingButton onClick={() => closeReview()}><span>Back</span></LoadingButton>
                </CardContent>
            </Card>
        </Grid>
    );
}



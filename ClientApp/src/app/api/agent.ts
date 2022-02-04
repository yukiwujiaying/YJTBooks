import axios, { AxiosError, AxiosRequestConfig, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { myHistory } from "../../history";
import { PaginatedResponse } from "../layout/models/pagination";
import { store } from "../store/configureStore";
import 'react-toastify/dist/ReactToastify.css';



const sleep = () => new Promise(resolve => setTimeout(resolve,500));

axios.defaults.baseURL = 'https://localhost:44316/api/';
axios.defaults.withCredentials = true;

const responseBody = (response: AxiosResponse) => response.data

//axios interceptors are functions that Axios calls for every request. 
//You can use interceptors to transform the request before Axios sends it, 
//or transform the response before Axios returns the response to your code.
axios.interceptors.request.use((config: AxiosRequestConfig) => {
    const token = store.getState().account.user?.token;
    if (token && config?.headers) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

axios.interceptors.response.use(async response =>{
    await sleep();
    console.log(response);
    const pagination = response.headers['pagination'];
    if (pagination) {
        response.data =  new PaginatedResponse(response.data, JSON.parse(pagination));
        //console.log(response);
        return response;
    }
    return response
},(error: AxiosError)=>{
    const{data,status}=error.response!;
    switch (status){
        case 400:
            if(data.errors){
                //create an empty array called ModelStateErrors
                const modelStateErrors: string[]=[];
                for(const key in data.errors){
                    if(data.errors[key]){
                        modelStateErrors.push(data.errors[key])
                    }
                }
                throw modelStateErrors.flat();
            }
            toast.error(data.title);
            break;
        case 401:
            toast.error(data.title );
            break;
        case 500:
            myHistory.push('/server-error', { state: {error: data}});
            
            break;
        default:
            break;
        
    }
    return Promise.reject(error.response);
})

const request = {
    get: (url:string, params?: URLSearchParams) => axios.get(url,{params}).then(responseBody),
    post: (url:string, body:{}) => axios.post(url,body).then(responseBody),
    put: (url:string, body:{}) => axios.put(url,body).then(responseBody),
    delete: (url:string) => axios.delete(url).then(responseBody),
}

const Catalog = {
    list:( params: URLSearchParams)=>request.get('Books', params),
    details: (id:number) => request.get(`Books/${id}`),
    fetchFilters:() => request.get('Books/filters')
}
const TestErrors ={
    get400Error:()=>request.get('buggy/bad-request'),
    get401Error:()=>request.get('buggy/unauthorised'),
    get404Error:()=>request.get('buggy/not-found'),
    get500Error:()=>request.get('buggy/server-error'),
    getValidationError:()=>request.get('buggy/validation-error'),
}
const FavouriteBookList = {
    get:() => request.get('FavouriteBookList'),
    addItem: (bookId: number) => request.post(`FavouriteBookList?bookId=${bookId}`, {}),
    RemoveItem:(bookId: number, quantity= 1)=> request.delete(`FavouriteBookList?bookId=${bookId}&quantity=${quantity}`)
}
const Account = {
    login: (values: any) => request.post('account/login', values),
    register: (values: any) => request.post('account/register', values),
    currentUser: () => request.get('account/currentUser'),
}

const Review = {
    addReview:(values:any, bookId:number, userId:string)=> request.post(`Review/addreview/${bookId}/${userId}`,values),
    modifyReview:(values:any, id:number)=> request.post(`Review/modifyreview/${id}`,values),
    deleteReview:(Id:number)=> request.delete(`Review?Id=${Id}`),
}

const agent = {
    Catalog,
    TestErrors,
    FavouriteBookList,
    Account,
    Review
}

export default agent;
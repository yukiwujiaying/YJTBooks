import axios, { AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { myHistory } from "../../history";



const sleep = () => new Promise(resolve => setTimeout(resolve,500));

axios.defaults.baseURL = 'https://localhost:44316/api/';
axios.defaults.withCredentials = true;

const responseBody = (response: AxiosResponse) => response.data

axios.interceptors.response.use(async response =>{
    await sleep();
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
            toast.error(data.title);
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
    get: (url:string) => axios.get(url).then(responseBody),
    post: (url:string, body:{}) => axios.post(url,body).then(responseBody),
    put: (url:string, body:{}) => axios.put(url,body).then(responseBody),
    delete: (url:string) => axios.delete(url).then(responseBody),
}

const Catalog = {
    list:()=>request.get('Books'),
    details: (id:number) => request.get(`Books/${id}`)
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
    addItem:(bookId: number, quantity= 1)=> request.post(`FavouriteBookList?bookId=${bookId}&quantity=${quantity}`,{}),
    removeItem:(bookId: number, quantity= 1)=> request.delete(`FavouriteBookList?bookId=${bookId}&quantity=${quantity}`)

}


const agent = {
    Catalog,
    TestErrors,
    FavouriteBookList
}

export default agent;
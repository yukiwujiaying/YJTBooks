import { User } from "../../app/models/user";


interface AccountState {
    user: User | null;
}

const initialState: AccountState = {
    user: null
}


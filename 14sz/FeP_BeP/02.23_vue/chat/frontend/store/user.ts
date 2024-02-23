import {defineStore} from 'pinia';

export type User = {
    userID: number;
    name: string;
    email:string;
    token: string;
  };
export const useUserStore = defineStore('user', () => {
    state: () =>(
        {
            user: {} as User }
        )
})
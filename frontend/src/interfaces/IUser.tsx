export default interface IUser {
    email: string;
    userName: string;
    picture?: string;
    id: string;
    lockoutEnabled?: boolean; 
}

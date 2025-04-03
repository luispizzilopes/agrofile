import Cookies from "js-cookie";

export default function createSession(token : string) : void {
    Cookies.set("token-agro-file", token, {
        expires: 10 / 24,
    }); 
}
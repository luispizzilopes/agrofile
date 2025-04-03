import { AxiosError } from "axios";
import getAllErrorMessages from "./getAllErrorMessages";

export default function handleError(error: unknown): string {
    if (error instanceof AxiosError) {
        if (error.response) {
            let data = error.response.data;
            let messages = data.errors ? getAllErrorMessages(data.errors) : [data.errorMessage]
            return messages[0];
        }

        return "Nenhuma resposta do servidor"; 
    }

    return "Ocorreu um erro."; 
}
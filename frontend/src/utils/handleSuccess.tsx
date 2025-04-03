import { AxiosResponse } from "axios";


export default function handleSuccess(response: AxiosResponse): string {
    if (response && response.data) {
        const responseData = response.data;
        return responseData.successMessage ?? "";
    }

    return "Nenhuma resposta do servidor";
}

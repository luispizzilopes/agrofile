import HttpStatusCode from "@/data/HttpStatusCode";
import IResetPasswordInterface from "@/interfaces/IResetPasswordInterface";
import api from "@/services/api";
import handleError from "@/utils/handleError";
import handleSuccess from "@/utils/handleSuccess";
import { toast } from "react-toastify";

export default async function resetPassword(params: IResetPasswordInterface): Promise<void> {
    const { email, setLoading } = params;

    setLoading(true);

    try {
        const response = await api.post("Authentication/reset-password", { email });

        if (response.status === HttpStatusCode.OK) {
            let message = handleSuccess(response); 
            toast.success(message);
        }
    } catch (error) {
        let message = handleError(error);
        toast.error(message);
    }

    setLoading(false);
}
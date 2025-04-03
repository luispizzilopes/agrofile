import HttpStatusCode from "@/data/HttpStatusCode";
import ISignInInterface from "@/interfaces/ISignInInterface";
import api from "@/services/api";
import createSession from "@/utils/createSession";
import handleError from "@/utils/handleError";
import { toast } from "react-toastify";

export default async function signIn(params: ISignInInterface): Promise<void> {
    const { email, password, setLoading, router } = params;

    setLoading(true);

    try {
        const response = await api.post("Authentication/sign-in", { email, password });

        if (response.status === HttpStatusCode.OK) {
            createSession(response.data?.value?.tokenJwtInformation?.token);
            router.push("/home");
        }
    } catch (error) {
        let message = handleError(error);
        toast.error(message);
    }

    setLoading(false);
}
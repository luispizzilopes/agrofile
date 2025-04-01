"use client";

import ISignInInterface from "@/interfaces/ISignInInterface";
import api from "@/services/api";

export default async function signIn(params: ISignInInterface): Promise<void> {
    const { setLoading } = params;

    setLoading(true);

    try {
        const response = await api.post("Authentication/sign-in", params);

        if (response.status === 200) {
            console.log("Logado");
        }
    } catch (error) {
        console.log("Erro ao autenticar");
    }

    setLoading(false);
}
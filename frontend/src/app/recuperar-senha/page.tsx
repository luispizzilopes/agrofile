"use client";

import { useRouter } from "next/navigation";
import { SproutIcon } from "lucide-react";
import { useLoading } from '@/contexts/LoadingContext';
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { useState } from 'react';
import { Card } from "primereact/card";
import resetPassword from "./features/resetPassword";

export default function RecuperarSenha() {
    const [email, setEmail] = useState<string>("");

    const router = useRouter();
    const { loading, setLoading } = useLoading();

    return (
        <div className="h-screen flex align-items-center justify-content-center">
            <Card className="p-2 shadow-2 border-round w-full lg:w-6">
                <div className="text-center mb-5">
                    <SproutIcon size={50} />
                    <div className="text-900 text-3xl font-medium mb-3">Recuperar Senha</div>
                    <span className="text-600 line-height-3">
                        Informe seu e-mail e enviaremos um link para redefinir sua senha.
                    </span>
                </div>

                <div>
                    <label htmlFor="email" className="block text-900 mb-2">
                        <i className="pi pi-envelope"></i> E-mail
                    </label>
                    <InputText
                        id="email"
                        type="email"
                        className="w-full mb-3"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />

                    <Button
                        label="Enviar link de recuperação"
                        icon="pi pi-send"
                        className="w-full"
                        loading={loading}
                        onClick={()=> resetPassword({ email, setLoading })}
                    />

                    <div className="mt-2 w-full text-center">
                        <Button
                            label="Voltar para o Login"
                            icon="pi pi-angle-left"
                            severity="secondary"
                            className="w-full"
                            onClick={() => router.push("/login")}
                        />
                    </div>
                </div>
            </Card>
        </div>
    );
}

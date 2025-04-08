"use client";

import { useRouter } from "next/navigation";
import { SproutIcon } from "lucide-react";
import { useLoading } from '@/contexts/LoadingContext';
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { useState } from 'react';
import getRootColor from "@/utils/getRootColor";
import signIn from "./features/signIn";
import { Card } from "primereact/card";

export default function Login() {
    const [email, setEmail] = useState<string>("");
    const [password, setPassword] = useState<string>("");

    const router = useRouter();
    const { loading, setLoading } = useLoading();

    return (
        <div className="h-screen flex align-items-center justify-content-center">
            <Card className="p-2 shadow-2 border-round w-full lg:w-6">
                <div className="text-center mb-5">
                    <SproutIcon size={50} />

                    <div className="text-900 text-3xl font-medium mb-3">Seja Bem-Vindo ao AgroFile</div>
                    <span className="text-600  line-height-3">Informe suas credenciais para realizar a autenticação</span>
                </div>

                <div>
                    <label htmlFor="email" className="block text-900  mb-2"><i className="pi pi-user"></i>  E-mail</label>
                    <InputText id="email" type="text" className="w-full mb-3" value={email} onChange={(e) => setEmail(e.target.value)} />

                    <label htmlFor="password" className="block text-900 mb-2"><i className="pi pi-lock"></i> Senha</label>
                    <InputText id="password" type="password" className="w-full mb-3" value={password} onChange={(e) => setPassword(e.target.value)} />

                    <div className="text-right justify-content-between mb-4">
                        <a onClick={() => router.push("/recuperar-senha")} className="no-underline ml-2 cursor-pointer">Esqueceu sua senha? Clique aqui</a>
                    </div>

                    <Button label="Entrar" icon="pi pi-user" className="w-full" onClick={()=> signIn({ email, password, setLoading, router })}/>
                </div>
            </Card>
        </div>
    );
}

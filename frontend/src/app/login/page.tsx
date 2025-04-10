"use client";

import { useLoading } from '@/contexts/LoadingContext';
import { SproutIcon } from "lucide-react";
import { useRouter } from "next/navigation";
import { Button } from "primereact/button";
import { Card } from "primereact/card";
import { InputText } from "primereact/inputtext";
import { useState } from 'react';
import signIn from "./features/signIn";
import getRootColor from '@/utils/getRootColor';

export default function Login() {
    const [email, setEmail] = useState<string>("");
    const [password, setPassword] = useState<string>("");

    const router = useRouter();
    const { loading, setLoading } = useLoading();

    return (
        <div className="h-screen flex align-items-center justify-content-center">
            <Card className="p-2 shadow-2 border-round w-full lg:w-6">
                <div className="text-center mb-5">
                    <SproutIcon size={50} id='system-icon' />

                    <div className="text-900 text-3xl font-medium mb-3">Seja Bem-Vindo ao AgroFile</div>
                    <span className="text-600  line-height-3">Informe suas credenciais para realizar a autenticação</span>
                </div>

                <div>
                    <label htmlFor="email" className="block text-900  mb-2"><i className="pi pi-user"></i>  E-mail</label>
                    <InputText id="email" type="text" className="w-full mb-3" value={email} onChange={(e) => setEmail(e.target.value)} />

                    <label htmlFor="password" className="block text-900 mb-2"><i className="pi pi-lock"></i> Senha</label>
                    <InputText id="password" type="password" className="w-full mb-3" value={password} onChange={(e) => setPassword(e.target.value)} />

                    <div className="text-right justify-content-between mb-4">
                        <a 
                            onClick={() => router.push("/reset-password")} 
                            className="no-underline ml-2 cursor-pointer"
                            style={{ color: "var(--primary-600)" }}
                        >
                            Esqueceu sua senha? Clique aqui
                        </a>
                    </div>

                    <Button loading={loading} label="Entrar" icon="pi pi-user" className="w-full" onClick={()=> signIn({ email, password, setLoading, router })}/>
                </div>
            </Card>
        </div>
    );
}

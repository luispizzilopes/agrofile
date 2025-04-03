"use client";

import signIn from './features/signIn';
import Loading from '@/components/Loading';
import { useLoading } from '@/contexts/LoadingContext';
import { LogIn } from 'lucide-react';
import { useRouter } from 'next/navigation';
import { useState } from 'react';

export default function Login() {
    const [email, setEmail] = useState<string>("");
    const [password, setPassword] = useState<string>("");

    const router = useRouter();
    const { loading, setLoading } = useLoading();

    return (
        <div className="flex items-center justify-center min-h-screen bg-base-200">
            <div className="card w-96 bg-base-100 shadow-xl p-6">
                <h2 className="text-2xl font-bold text-center text-primary">AgroFile</h2>
                <p className="text-center text-sm text-gray-500 mt-2">
                    Informe suas credenciais para realizar a autenticação
                </p>
                <div className="mt-4 space-y-4">
                    <div className="form-control">
                        <label className="label">
                            <span className="label-text mb-2">E-mail</span>
                        </label>
                        <input
                            type="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            className="input input-bordered w-full"
                            required
                        />
                    </div>
                    <div className="form-control">
                        <label className="label">
                            <span className="label-text mb-2">Senha</span>
                        </label>
                        <input
                            type="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            className="input input-bordered w-full"
                            required
                        />
                    </div>
                    <button type="submit" className="btn btn-primary w-full" onClick={async () => await signIn({
                        email: email,
                        password: password,
                        router: router,
                        setLoading: setLoading,
                    })}>
                        <LogIn />Entrar
                    </button>
                    <div className="text-end">
                        <a className="link link-primary" onClick={() => router.push("/recuperar-senha")}>Esqueceu sua senha? Clique aqui</a>
                    </div>
                </div>
            </div>

            <div className="fixed bottom-3 right-3">
                <p className="text-primary-500 text-sm">
                    {new Date().getFullYear().toString()} Copyright © - Desenvolvido por eXtend File.</p>
            </div>

            <Loading isLoading={loading} />
        </div>
    );
}

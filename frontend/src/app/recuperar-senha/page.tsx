"use client";

import { Mail } from 'lucide-react';
import { useRouter } from 'next/navigation';
import { useLoading } from '@/contexts/LoadingContext';
import Loading from '@/components/Loading';
import { useState } from 'react';
import resetPassword from './features/resetPassword';

export default function RecuperarSenha() {
    const [email, setEmail] = useState<string>("");

    const router = useRouter();
    const { loading, setLoading } = useLoading();

    return (
        <div className="flex items-center justify-center min-h-screen bg-base-200">
            <div className="card w-96 bg-base-100 shadow-xl p-6">
                <h2 className="text-2xl font-bold text-center text-primary">Recuperar Senha</h2>
                <p className="text-center text-sm text-gray-500 mt-2">
                    Digite seu e-mail para receber um link de redefinição de senha.
                </p>
                <div className="mt-4 space-y-4">
                    <div className="form-control">
                        <label className="label">
                            <span className="label-text mb-2">E-mail</span>
                        </label>
                        <input
                            type="email"
                            className="input input-bordered w-full"
                            required
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                        />
                    </div>
                    <button type="submit" className="btn btn-primary w-full" onClick={() => { resetPassword({ email, setLoading }) }}>
                        <Mail /> Enviar Link
                    </button>
                    <div className="text-end">
                        <a onClick={() => router.push("/login")} className="link link-primary">Voltar para Login</a>
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

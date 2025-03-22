'use client';
import { LogIn } from 'lucide-react';

export default function Login() {
    return (
        <div className="flex items-center justify-center min-h-screen bg-base-200">
            <div className="card w-96 bg-base-100 shadow-xl p-6">
                <h2 className="text-2xl font-bold text-center text-primary">AgroFIle</h2>
                <form className="mt-4 space-y-4">
                    <div className="form-control">
                        <label className="label">
                            <span className="label-text mb-2">E-mail</span>
                        </label>
                        <input
                            type="email"
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
                            className="input input-bordered w-full"
                            required
                        />
                    </div>
                    <button type="submit" className="btn btn-primary w-full">
                        <LogIn />Entrar</button>
                </form>
            </div>
        </div>
    );
}

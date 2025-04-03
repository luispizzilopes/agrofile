import type { AppRouterInstance } from "next/dist/shared/lib/app-router-context.shared-runtime";

export default interface ISignInInterface {
    email: string;
    password: string;
    router: AppRouterInstance;
    setLoading: (loading: boolean) => void;
}

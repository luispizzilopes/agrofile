"use client";
import EndpointsApi from "@/data/EndpointsApi"; 

import DefaultPage from "@/components/DefaultPage";
import { GenericTable } from "@/components/GenericTablePagination";
import { Users } from "lucide-react";

export default function Page() {
    return <DefaultPage title="Usuários" icon={<Users />}>
        <main>
            <h1>Listagem de Usuários</h1>
            <GenericTable endpoint={EndpointsApi.USERS}/>
        </main>
    </DefaultPage>
}
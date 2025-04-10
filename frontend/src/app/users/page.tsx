"use client";

import { useState } from "react";
import DefaultPage from "@/components/DefaultPage";
import { Users } from "lucide-react";
import { TableUsers } from "./sessions/TableUsers";
import { Button } from "primereact/button";
import FilterUsers from "./sessions/FilterUsers";
import IFilterUserInterface from "@/interfaces/IFilterUserInterface";

export default function Page() {
    const [filters, setFilters] = useState<IFilterUserInterface>({
        name: "",
        status: null,
    });

    return (
        <DefaultPage title="Usuários" icon={<Users />}>
            <main>
                <div className="flex justify-content-end mb-2">
                    <Button label="Adicionar Usuário" icon="pi pi-plus" rounded />
                </div>

                <FilterUsers filters={filters} setFilters={setFilters} />

                <TableUsers pageSize={10} filters={filters} />
            </main>
        </DefaultPage>
    );
}

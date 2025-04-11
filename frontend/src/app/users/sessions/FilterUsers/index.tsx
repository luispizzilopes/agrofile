"use client";

import { Button } from "primereact/button";
import { Dropdown } from "primereact/dropdown";
import { InputText } from "primereact/inputtext";
import IFilterUserInterface from "@/interfaces/IFilterUserInterface";

interface FilterUsersProps {
    filters: IFilterUserInterface;
    setFilters: (filters: IFilterUserInterface) => void;
}

export default function FilterUsers({ filters, setFilters }: FilterUsersProps) {
    const statusOptions = [
        { label: 'Sim', value: true },
        { label: 'Não', value: false },
    ];

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFilters((prev: IFilterUserInterface) => ({
            ...prev,
            [e.target.name]: e.target.value,
        }));
    };

    const handleStatusChange = (e: any) => {
        setFilters((prev: IFilterUserInterface) => ({
            ...prev,
            status: e.value,
        }));
    };

    const handleClearFilters = () => {
        setFilters({ name: '', status: null });
        (document.getElementById("name") as HTMLInputElement).value = "";
    };

    return (
        <div className="mb-2 flex flex-column md:flex-row md:align-items-center gap-4 md:gap-3">
            <span className="p-float-label w-full md:w-5">
                <InputText
                    id="name"
                    name="name"
                    defaultValue={filters.name}
                    onBlur={handleInputChange}
                    className="w-full"
                />
                <label htmlFor="name">Nome</label>
            </span>

            <span className="p-float-label w-full md:w-2">
                <Dropdown
                    id="status"
                    value={filters.status}
                    options={statusOptions}
                    onChange={handleStatusChange}
                    className="w-full"
                    placeholder="Selecione o status"
                />
                <label htmlFor="status">Ativo</label>
            </span>

            <div className="w-full md:w-auto">
                <Button
                    size="small"
                    icon="pi pi-times"
                    label="Limpar Filtro"
                    onClick={handleClearFilters}
                    outlined
                    rounded
                    className="w-full md:w-auto"
                />
            </div>
        </div>


    );
}

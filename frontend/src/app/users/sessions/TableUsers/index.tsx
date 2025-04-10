"use client";

import EndpointsApi from '@/data/EndpointsApi';
import IUser from '@/interfaces/IUser';
import IFilterUserInterface from '@/interfaces/IFilterUserInterface';
import api from '@/services/api';
import { Button } from "primereact/button";
import { Avatar } from 'primereact/avatar';
import { Column } from "primereact/column";
import { DataTable } from "primereact/datatable";
import { useEffect, useState } from 'react';
import getRootColor from '@/utils/getRootColor';

export function TableUsers({ pageSize, filters }: { pageSize: number; filters: IFilterUserInterface }) {
    const [data, setData] = useState<IUser[]>([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [totalPages, setTotalPages] = useState(1);

    useEffect(() => {
        setCurrentPage(1);
    }, [filters]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await api.get(EndpointsApi.USERS, {
                    params: {
                        PageNumber: currentPage,
                        PageSize: pageSize,
                        UserName: filters.name || undefined,
                        Active: filters.status !== null ? filters.status : undefined,
                    },
                });

                const json = response.data;
                setData(json.data);
                setTotalPages(json.totalPages);
            } catch (error) {
                console.error('Erro ao buscar dados:', error);
            }
        };

        fetchData();
    }, [currentPage, pageSize, filters]);

    const nextPage = () => {
        if (currentPage < totalPages) setCurrentPage((prev) => prev + 1);
    };

    const previousPage = () => {
        if (currentPage > 1) setCurrentPage((prev) => prev - 1);
    };

    return (
        <>
            <div className="overflow-x">
                <DataTable
                    emptyMessage="Nenhum usuário encontrado"
                    showGridlines
                    value={data}
                    tableStyle={{ minWidth: '50rem' }}
                >
                    <Column
                        header="Foto"
                        headerStyle={{ textAlign: "center" }}
                        body={(rowData: IUser) => <div className="flex justify-content-center"> {
                            rowData?.picture != null && rowData.picture != "" ? <img src={rowData?.picture} />
                                : <Avatar label={rowData?.userName[0].toUpperCase()} shape="circle" style={{ backgroundColor: getRootColor("--primary-300") }} />
                        } </div>}
                    />
                    <Column
                        header="Nome"
                        body={(rowData: IUser) => <p className='font-semibold'>{rowData?.userName}</p>}
                    />
                    <Column
                        header="E-mail"
                        body={(rowData: IUser) => <p className='font-semibold'>{rowData?.email}</p>}
                    />
                    <Column
                        header="Ativo"
                        body={(rowData: IUser) => (
                            <div className="flex justify-content-center gap-2">
                                <i
                                    className={`pi ${rowData?.active ? "pi-check-circle" : "pi-times-circle"}`}
                                    style={{ fontSize: '1.2rem', color: getRootColor(rowData?.active ? "--green-500" : "--red-500") }}
                                />
                                <span className="font-medium">
                                    {rowData?.active ? "Sim" : "Não"}
                                </span>
                            </div>
                        )}
                    />
                    <Column
                        header="Identificador"
                        body={(rowData: IUser) => <p className='font-medium'>{rowData?.id}</p>}
                    />
                    <Column
                        header="Ações"
                        body={(rowData) =>
                            <div className='flex justify-content-center gap-2'>
                                <Button icon="pi pi-pencil" rounded outlined size='small' tooltip='Editar' tooltipOptions={{ position: "bottom" }} />
                                <Button icon="pi pi-trash" rounded outlined size='small' tooltip='Excluir' tooltipOptions={{ position: "bottom" }} />
                            </div>
                        }
                    />
                </DataTable>
            </div>

            <div className="flex justify-content-center align-items-center mt-4">
                <Button
                    label="Anterior"
                    icon="pi pi-arrow-left"
                    onClick={previousPage}
                    disabled={currentPage === 1}
                    severity="secondary"
                    outlined
                    className="p-button-sm"
                />

                <span className="text-sm text-color-secondary mx-3">
                    Página <strong>{currentPage}</strong> de <strong>{totalPages}</strong>
                </span>

                <Button
                    label="Próxima"
                    icon="pi pi-arrow-right"
                    iconPos="right"
                    onClick={nextPage}
                    disabled={currentPage === totalPages}
                    severity="secondary"
                    outlined
                    className="p-button-sm"
                />
            </div>
        </>
    );
}

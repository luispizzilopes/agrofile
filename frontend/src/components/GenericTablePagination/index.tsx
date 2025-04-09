import React, { useEffect, useState } from 'react';
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Button } from "primereact/button";
import api from '@/services/api';

interface GenericTableProps<T> {
  endpoint: string;
  pageSize?: number;
  tableColumnsNames?: Array<string>
}

export function GenericTable<T extends Record<string, any>>({
  endpoint,
  pageSize = 10,
  tableColumnsNames
}: GenericTableProps<T>) {
  const [data, setData] = useState<T[]>([]);
  const [columns, setColumns] = useState<string[]>([]);
  const [columnsNames, setColumnsNames] = useState<string[]>([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await api.get(endpoint, {
          params: {
            PageNumber: currentPage,
            PageSize: pageSize,
          },
        });

        const json = response.data;
        setData(json.data);
        setTotalPages(json.totalPages);

        if (json.data.length > 0) {
          setColumns(Object.keys(json.data[0]));
        }

        if (tableColumnsNames != undefined && tableColumnsNames?.length > 0) {
          setColumnsNames(tableColumnsNames)
        }
      } catch (error) {
        console.error('Erro ao buscar dados:', error);
      }
    };

    fetchData();
  }, [currentPage, pageSize, endpoint]);

  const nextPage = () => {
    if (currentPage < totalPages) setCurrentPage((prev) => prev + 1);
  };

  const previousPage = () => {
    if (currentPage > 1) setCurrentPage((prev) => prev - 1);
  };

  return (
    <>
      <div className="overflow-auto">
        <DataTable
          showGridlines
          value={data}
          paginator={false}
          className="p-datatable-sm"
          tableStyle={{ minWidth: '50rem' }}
        >
          {columns.map((col, index) => (
            <Column
              key={col}
              field={col}
              header={columnsNames != undefined && columnsNames.length > 0 ? columnsNames[index] : col}
              headerStyle={{ fontWeight: '600' }}
            />
          ))}
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

import React, { useEffect, useState } from 'react';
import api from '@/services/api'; 

interface GenericTableProps<T> {
  endpoint: string;
  pageSize?: number;
}

export function GenericTable<T extends Record<string, any>>({
  endpoint,
  pageSize = 10,
}: GenericTableProps<T>) {
  const [data, setData] = useState<T[]>([]);
  const [columns, setColumns] = useState<string[]>([]);
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
    <div className="p-4">
      <div className="overflow-x-auto">
        <table className="table table-zebra w-full">
          <thead>
            <tr>
              {columns.map((column) => (
                <th key={column}>{column}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            {data.map((item, index) => (
              <tr key={index}>
                {columns.map((column) => (
                  <td key={column}>{item[column]}</td>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <div className="flex justify-between items-center mt-4">
        <button
          onClick={previousPage}
          disabled={currentPage === 1}
          className="btn btn-outline btn-primary"
        >
          ⬅ Anterior
        </button>
        <span className="text-sm">
          Página {currentPage} de {totalPages}.
        </span>
        <button
          onClick={nextPage}
          disabled={currentPage === totalPages}
          className="btn btn-outline btn-primary"
        >
          Próxima ➡
        </button>
      </div>
    </div>
  );
}

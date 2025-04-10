import { useLoading } from '@/contexts/LoadingContext';
import { useSidebar } from '@/contexts/SidebarContext';
import { Card } from 'primereact/card';
import { ReactNode } from 'react';
import Header from '../Header';
import Loading from '../Loading';

interface DefaultPageProps {
  title: string;
  icon: any;
  children: ReactNode;
}

export default function DefaultPage({ title, icon, children }: DefaultPageProps) {
  const { loading } = useLoading();
  const { open } = useSidebar();

  return (


      <div className="flex flex-column flex-1">
        <Header />

        <div className="flex flex-column flex-1 px-2 py-1">
          <Card className="flex flex-column flex-1">
            <div className="flex align-items-center gap-2">
              {icon}
              <h1 className="text-xl font-bold m-0">{title}</h1>
            </div>

            <div className="my-3 border-top-1 surface-border" />

            <div className="flex-1">
              {children}
            </div>
          </Card>
        </div>


      <Loading isLoading={loading} />

      <style global jsx>{`
        .p-datatable .p-datatable-thead > tr > th {
          background-color: var(--primary-color); /* Cor primária do tema */
          color: var(--primary-color-text); /* Cor do texto primário */
          text-align: center; /* Centraliza o texto do cabeçalho */
          font-weight: bold; /* Negrito no texto */
        }

        .p-sortable-column-icon {
          color: var(--primary-color-text); /* Cor do texto primário */
        }
      `}</style>

    </div>
  );
}

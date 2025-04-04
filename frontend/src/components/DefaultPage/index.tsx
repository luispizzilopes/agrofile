import { ReactNode } from 'react';
import Loading from '../Loading';
import { useLoading } from '@/contexts/LoadingContext';
import Sidebar, { SidebarItem } from '../Sidebar';
import { Home } from 'lucide-react';
import Header from '../Header';

interface DefaultPageProps {
  title: string;
  icon: any;
  children: ReactNode;
}

export default function DefaultPage({ title, icon, children }: DefaultPageProps) {
  const { loading } = useLoading();

  return (
    <div className="flex h-screen">
      <div className="h-screen w-64 bg-white flex flex-col fixed top-0 left-0">
        <Sidebar>
          <SidebarItem icon={<Home size={20} />} text="Início" active />
        </Sidebar>
      </div>

      <div className="flex flex-col flex-1 ml-64">
        <Header />

        <div className="flex-1 flex flex-col p-2">
          <div className="flex-1 rounded-sm border border-[oklch(28.036%_0.019_264.182)] p-4 bg-muted">

            <div className="flex items-center gap-2 mb-2">
              {icon}
              <h1 className="text-lg font-bold">{title}</h1>
            </div>
            <div className="border-t border-border" />
            <div className="mt-4 flex-1">{children}</div>
          </div>
        </div>
      </div>

      <Loading isLoading={loading} />
    </div>
  );
}

import { useLoading } from '@/contexts/LoadingContext';
import { ReactNode } from 'react';
import Header from '../Header';
import Loading from '../Loading';
import Sidebar from '../Sidebar';
import { useSidebar } from '@/contexts/SidebarContext';

interface DefaultPageProps {
  title: string;
  icon: any;
  children: ReactNode;
}

export default function DefaultPage({ title, icon, children }: DefaultPageProps) {
  const { loading } = useLoading();
  const { open } = useSidebar();

  return (
    <div className="flex h-screen">
      {
        open && <div className={`h-screen w-64 bg-white flex flex-col fixed top-0 left-0 z-50 md:relative md:block ${true ? "block" : "hidden md:block"}`}>
          <Sidebar />
        </div>
      }


      <div className={`flex flex-col flex-1  ${false ? "ml-32 md:ml-64" : ""}`}>
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

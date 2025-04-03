import { ReactNode } from 'react';
import Loading from '../Loading';
import { useLoading } from '@/contexts/LoadingContext';

interface DefaultPageProps {
  children: ReactNode;
}

export default function DefaultPage({ children }: DefaultPageProps) {
  const { loading } = useLoading();

  return (
    <div>
      <div>{children}</div>

      <Loading isLoading={loading} />
    </div>
  );
}

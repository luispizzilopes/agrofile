"use client";

import ILoadingContextInterface from '@/interfaces/ILoadingContextInterface';
import { createContext, useState, useContext, ReactNode } from 'react';

interface ILoadingProviderProps {
  children: ReactNode;
}

const LoadingContext = createContext<ILoadingContextInterface | undefined>(undefined);

export const LoadingProvider = ({ children }: ILoadingProviderProps) => {
  const [loading, setLoading] = useState<boolean>(false);

  return (
    <LoadingContext.Provider value={{ loading, setLoading }}>
      {children}
    </LoadingContext.Provider>
  );
};

export const useLoading = (): ILoadingContextInterface => {
  const context = useContext(LoadingContext);
  if (!context) {
    throw new Error('useLoading must be used within a LoadingProvider');
  }
  return context;
};

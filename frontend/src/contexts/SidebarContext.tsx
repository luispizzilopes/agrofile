"use client";

import { createContext, useState, useContext, ReactNode } from 'react';

interface ISidebarContextInterface {
    open: boolean,
    setOpen: (state: boolean) => void;
}

interface ISidebarProviderProps {
    children: ReactNode;
}

const SidebarContext = createContext<ISidebarContextInterface | undefined>(undefined);

export const SidebarProvider = ({ children }: ISidebarProviderProps) => {
    const [open, setOpen] = useState<boolean>(true);

    return (
        <SidebarContext.Provider value={{ open, setOpen }}>
            {children}
        </SidebarContext.Provider>
    );
};

export const useSidebar = () => {
    const context = useContext(SidebarContext);
    if (!context) {
        throw new Error('useSidebar must be used within a SidebarProvider');
    }
    return context;
};
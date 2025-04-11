"use client";

import { SproutIcon } from "lucide-react";
import { useRouter } from "next/navigation";
import { Menubar } from "primereact/menubar";
import { createItemsHeader } from "./data/ItemsHeader";

export default function Header() {
    const router = useRouter(); 
    const itemsHeader = createItemsHeader(router); 

    return (
        <div className="px-1 py-1 w-full">
            <Menubar
                model={itemsHeader}
                start={
                    <div className="flex align-items-center gap-2 font-bold text-xl text-color mx-3">
                        <SproutIcon size={30} id="system-icon"/>
                        AgroFile
                    </div>
                }
                end={<div className="flex align-items-center gap-2"></div>}
                className="shadow-1"
                style={{ height: '75px', background: 'var(--surface-a)', width: '100%' }}
            />

        </div>

    );
}

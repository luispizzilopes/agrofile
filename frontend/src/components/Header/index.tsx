"use client";

import { useSidebar } from "@/contexts/SidebarContext";
import { SproutIcon } from "lucide-react";
import { Menubar } from "primereact/menubar";
import { Button } from "primereact/button";

export default function Header() {
    const { open, setOpen } = useSidebar();

    const start = (
        <div className="flex align-items-center gap-3">
            <Button
                rounded
                outlined
                text
                size="small"
                severity="secondary"
                icon={open ? "pi pi-arrow-left" : "pi pi-arrow-right"}
                className="p-button-sm"
                onClick={() => setOpen(!open)}
                aria-label="Alternar menu lateral"
            />

            <div className="flex align-items-center gap-2 font-bold text-xl text-color">
                <SproutIcon size={22} />
                AgroFile
            </div>
        </div>
    );

    const end = (
        <div className="flex align-items-center gap-2">
            {/* Conteúdo adicional do lado direito, se necessário */}
        </div>
    );

    return (
        <div className="px-2 py-1">
            <Menubar
                start={start}
                end={end}
                className="shadow-1"
                style={{ height: "75px", background: "var(--surface-a)" }}
            />
        </div>

    );
}

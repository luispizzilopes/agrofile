"use client";

import { useSidebar } from "@/contexts/SidebarContext";
import { Home, Menu, Users } from "lucide-react";
import { useRouter } from "next/navigation";
import { Button } from "primereact/button";
import { ReactNode } from "react";

import "./style.css";

export default function Sidebar() {
  const { open, setOpen } = useSidebar();

  return (
    <aside className="h-full w-full md:w-18rem surface-overlay text-color fixed md:static z-5">
      <nav className="h-full flex flex-column shadow-2 overflow-hidden" style={{ background: "var(--surface-a)" }}>
        <div className="py-3 px-3 flex justify-content-between align-items-center">
          <h1 className="text-xl flex align-items-center gap-2 overflow-hidden transition-all m-0">
            <Menu size={25} />
            Menu
          </h1>

          <Button 
            style={{ display: "none", position: "fixed", top: 10, right: 10 }}
            id="close-sidebar-button" 
            icon="pi pi-times" 
            onClick={()=> setOpen(!open)} 
            rounded 
            outlined 
            severity="secondary"
          />
        </div>

        <ul className="flex-1 px-3 my-0">
          <SidebarItem icon={<Home size={20} />} text="Início" route="home" />
          <SidebarItem icon={<Users size={20} />} text="Usuários" route="users" />
        </ul>
      </nav>
    </aside>
  );
}

type SidebarItemProps = {
  icon: ReactNode;
  text: string;
  active?: boolean;
  alert?: boolean;
  route: string;
};

export function SidebarItem({ icon, text, active = false, alert = false, route }: SidebarItemProps) {
  const router = useRouter();

  return (
    <li
      onClick={() => router.push(`/${route}`)}
      className={`relative flex align-items-center py-2 px-3 my-1 border-round cursor-pointer transition-colors surface-hover text-color ${active ? 'bg-primary text-primary-900' : ''}`}
    >
      <div>{icon}</div>
      <span className="overflow-hidden transition-all w-12 ml-3">{text}</span>

      {alert && <div className="absolute right-2 w-2 h-2 border-circle bg-orange-500" />}

      <div className="absolute left-full border-round px-2 py-1 ml-3 bg-primary text-primary-900 text-sm invisible opacity-0 -translate-x-2 transition-all transition-duration-200 transition-ease-in-out group-hover:visible group-hover:opacity-100 group-hover:translate-x-0">
        {text}
      </div>
    </li>
  );
}

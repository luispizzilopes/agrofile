import { useSidebar } from "@/contexts/SidebarContext";
import { Home, Menu, Users } from "lucide-react";
import { CircleX } from "lucide-react";
import { ReactNode } from "react";

export default function Sidebar() {
  const { open, setOpen } = useSidebar();

  return (
    <aside className="h-screen w-screen md:w-auto bg-[oklch(24.731%_0.02_264.094)] text-[oklch(82.901%_0.031_222.959)] md:w-[300px] fixed md:relative z-50">
      <nav className="h-full flex flex-col shadow-sm overflow-hidden">
        <div className="p-4 pb-2 flex justify-between items-center">
          <h1
            className={`text-xl font-bold tracking-wide flex items-center gap-2 text-[oklch(90%_0.04_222.959)] overflow-hidden transition-all`}
          >
            <Menu size={25} />
            Menu
          </h1>

          <button className="btn btn-ghost btn-sm sm:hidden" onClick={() => setOpen(!open)}>
            <CircleX size={25} />
          </button>
        </div>

        <ul className="flex-1 px-3">
          <SidebarItem icon={<Home size={20} />} text="Início" />
          <SidebarItem icon={<Users size={20} />} text="Usuários" />
        </ul>

        <div className="border-t border-[oklch(28.036%_0.019_264.182)] flex p-3">
          <img
            src="https://ui-avatars.com/api/?background=c7d2fe&color=3730a3&bold=true"
            alt="User Avatar"
            className="w-10 h-10 rounded-md"
          />
          <div
            className={`flex justify-between items-center overflow-hidden transition-all w-52 ml-3`}
          >
            <div className="leading-4">
              <h4 className="font-semibold text-[oklch(82.901%_0.031_222.959)]">John Doe</h4>
              <span className="text-xs text-[oklch(82.901%_0.031_222.959)]">johndoe@gmail.com</span>
            </div>
          </div>
        </div>
      </nav>
    </aside>

  );
}

type SidebarItemProps = {
  icon: ReactNode;
  text: string;
  active?: boolean;
  alert?: boolean;
};

export function SidebarItem({ icon, text, active = false, alert = false }: SidebarItemProps) {
  return (
    <li
      className={`
        relative flex items-center py-2 px-3 my-1
        font-medium rounded-md cursor-pointer
        transition-colors group
        ${active ? "bg-[oklch(86.133%_0.141_139.549)] text-[oklch(17.226%_0.028_139.549)]" : "text-[oklch(82.901%_0.031_222.959)]"}
      `}
    >
      <div>{icon}</div>
      <span className={`overflow-hidden transition-all w-52 ml-3`}>{text}</span>
      {alert && <div className={`absolute right-2 w-2 h-2 rounded bg-[oklch(73.375%_0.165_35.353)]`} />}


      <div
        className="
          absolute left-full rounded-md px-2 py-1 ml-6
          bg-[oklch(86.171%_0.142_166.534)] text-[oklch(17.234%_0.028_166.534)] text-sm
          invisible opacity-20 -translate-x-3 transition-all
          group-hover:visible group-hover:opacity-100 group-hover:translate-x-0
        "
      >
        {text}
      </div>

    </li>
  );
}

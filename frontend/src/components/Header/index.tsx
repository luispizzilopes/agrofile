import { useSidebar } from "@/contexts/SidebarContext";
import { SproutIcon, SkipBack, SkipForward } from "lucide-react";

export default function Header() {
    const { open, setOpen } = useSidebar();

    return (
        <div className="navbar bg-[oklch(24.731%_0.02_264.094)] text-[oklch(82.901%_0.031_222.959)] shadow-sm border-l border-[oklch(28.036%_0.019_264.182)]" style={{ height: "75px" }}>
            <div className="navbar-start">
                <button className="btn btn-ghost btn-sm" onClick={()=> setOpen(!open)}>
                    {open ? <SkipBack style={{ fontSize: "10px" }} /> : <SkipForward style={{ fontSize: "10px" }} />}
                </button>
                <a className="btn btn-ghost text-xl text-left text-[oklch(90%_0.04_222.959)]"><SproutIcon /> AgroFile</a>
            </div>
            <div className="navbar-end">

            </div>
        </div>
    );
}

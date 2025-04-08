import { LoadingProvider } from "@/contexts/LoadingContext";
import { PrimeReactProvider } from 'primereact/api';
import ClientSideToastContainer from "@/components/ClientSideToastContainer";
import type { Metadata } from "next";
import { SidebarProvider } from "@/contexts/SidebarContext";
import { Geist, Geist_Mono } from "next/font/google";

import "primereact/resources/themes/saga-green/theme.css";
import 'primereact/resources/primereact.min.css';
import 'primeicons/primeicons.css';
import "primeflex/primeflex.css";
import "./globals.css";

const geistSans = Geist({
  variable: "--font-geist-sans",
  subsets: ["latin"],
});

const geistMono = Geist_Mono({
  variable: "--font-geist-mono",
  subsets: ["latin"],
});

export const metadata: Metadata = {
  title: "AgroFile",
  description: "Desenvolvido por eXtend File",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {

  return (
    <html lang="pt-br" data-theme="dim">
      <body
        className={`${geistSans.variable} ${geistMono.variable} antialiased`}
      >
        <PrimeReactProvider>
          <ClientSideToastContainer />
          <LoadingProvider>
            <SidebarProvider>
              {children}
            </SidebarProvider>

          </LoadingProvider>
        </PrimeReactProvider>

      </body>
    </html>
  );
}

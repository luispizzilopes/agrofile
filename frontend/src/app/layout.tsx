import { LoadingProvider } from "@/contexts/LoadingContext";
import ClientSideToastContainer from "@/components/ClientSideToastContainer";
import type { Metadata } from "next";
import { Geist, Geist_Mono } from "next/font/google";
import "./globals.css";
import { SidebarProvider } from "@/contexts/SidebarContext";

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
        <ClientSideToastContainer />
        <LoadingProvider>
          <SidebarProvider>
            {children}
          </SidebarProvider>

        </LoadingProvider>
      </body>
    </html>
  );
}

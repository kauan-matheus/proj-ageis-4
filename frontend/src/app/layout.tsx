import type { Metadata } from "next";
import { Geist, Geist_Mono } from "next/font/google";
import "../styles/globals.css";

export default function RootLayout({ children }: LayoutProps<"/">) {
  return (
    <html
      lang="en"
      className="h-full antialiased"
    >
      <head>
        <title>Projetos Ageis</title>
      </head>
      <body className="min-h-full flex flex-col">{children}</body>
    </html>
  );
}

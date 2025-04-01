interface LoadingProps {
    isLoading: boolean;
  }
  
export default function Loading({ isLoading }: LoadingProps) {
    return (
        isLoading && (
        <div className="fixed inset-0 flex items-center justify-center backdrop-blur-sm bg-black/30 z-50">
            <span className="loading loading-spinner text-primary"></span>
        </div>
        )
    );
}
  
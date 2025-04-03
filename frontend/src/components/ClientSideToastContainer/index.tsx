'use client'

import 'react-toastify/dist/ReactToastify.css'
import { ToastContainer } from 'react-toastify'

const ClientSideToastContainer = () => <ToastContainer
    position="top-right"
    autoClose={5000}
    hideProgressBar={false}
    newestOnTop={false}
    closeOnClick={false}
    rtl={false}
    pauseOnFocusLoss
    draggable
    pauseOnHover
    theme="colored"
/>

export default ClientSideToastContainer; 